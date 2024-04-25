import { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import TimService from "../../services/TimService";
import { MdAddCircleOutline } from "react-icons/md";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";

export default function Timovi() {
    const [timovi, setTimovi] = useState();

    async function dohvatiTimove() {
        await TimService.getTimovi()
            .then((res) => {
                setTimovi(res.data);
            })
            .catch((e) => {
                alert(e);
            });
    }

    useEffect(() => {
        dohvatiTimove();
    }, []);

    async function obrisi(tim) {
        await TimService.deleteTim(tim.id)
            .then((res) => {
                dohvatiTimove();
            })
            .catch((e) => {
                alert(e);
            });
    }

    return (
        <Container>
            <Link to={RoutesNames.TIMOVI_NOVI} className="btn btn-success gumb">
                <MdAddCircleOutline
                    size={25}
                /> Dodaj
            </Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Ime tima</th>
                        <th>Država sjedišta</th>
                        <th>Godina osnutka</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {timovi && timovi.map((tim, index) => (
                        <tr key={index}>
                            <td>{tim.ime_tima}</td>
                            <td className="desno">{tim.drzava_sjedista}</td>
                            <td className="desno">{tim.godina_osnutka}</td>
                            <td className="sredina">
                                <Link to={RoutesNames.TIMOVI_PROMIJENI}>
                                    <FaEdit
                                        size={25}
                                    />
                                </Link>

                                &nbsp;&nbsp;&nbsp;
                                <Link onClick={obrisi(tim)}>
                                    <FaTrash
                                        size={25}
                                    />
                                </Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}