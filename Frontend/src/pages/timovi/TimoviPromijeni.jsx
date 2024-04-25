import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import TimService from "../../services/TimService";
import { RoutesNames } from "../../constants";

export default function TimoviPromijeni() {
    const navigate = useNavigate();
    const routeParams = useParams();
    const [tim, setTim] = useState({});

    async function dohvatiTim() {
        await TimService.getById(routeParams.id)
            .then((res) => {
                setTim(res.data)
            })
            .catch((e) => {
                alert(e.poruka);
            });
    }

    useEffect(() => {
        dohvatiTim();
    }, []);

    async function promijeniTim(tim) {
        const odgovor = await TimService.promijeniTim(routeParams.id, tim);
        if (odgovor.ok) {
            navigate(RoutesNames.TIMOVI_PREGLED);
        } else {
            console.log(odgovor);
            alert(odgovor.poruka);
        }
    }

    function handleSubmit(e) {
        e.preventDefault();
        const podaci = new FormData(e.target);

        const tim =
        {
            ime_tima: podaci.get('ime_tima'),
            drzava_sjedista: podaci.get('drzava_sjedista'),
            godina_osnutka: parseInt(podaci.get('godina_osnutka'))
        };
        //console.log(JSON.stringify(tim));
        promijeniTim(tim);
    }

    return (
        <Container>
            <Form onSubmit={handleSubmit}>

                <Form.Group controlId="ime_tima">
                    <Form.Label>Ime tima</Form.Label>
                    <Form.Control
                        type="text"
                        defaultValue={tim.ime_tima}
                        name="ime_tima"
                    />
                </Form.Group>

                <Form.Group controlId="drzava_sjedista">
                    <Form.Label>Država sjedišta</Form.Label>
                    <Form.Control
                        type="text"
                        defaultValue={tim.drzava_sjedista}
                        name="drzava_sjedista"
                    />
                </Form.Group>

                <Form.Group controlId="godina_osnutka">
                    <Form.Label>Godina osnutka</Form.Label>
                    <Form.Control
                        type="text"
                        defaultValue={tim.godina_osnutka}
                        name="godina_osnutka"
                    />
                </Form.Group>

                <Row className="akcije">
                    <Col>
                        <Link
                            className="btn btn-danger"
                            to={RoutesNames.TIMOVI_PREGLED}>Odustani</Link>
                    </Col>
                    <Col>
                        <Button
                            variant="primary"
                            type="submit"
                        >
                            Promijeni smjer
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>
    );
}