import { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import TimService from "../../services/TimService";

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

    return (
        <Container>
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
                            <td>Akcija</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}