import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { RoutesNames } from "../../constants";
import { Link, useNavigate } from "react-router-dom";
import TimService from "../../services/TimService";


export default function TimoviDodaj() {
    const navigate = useNavigate();

    async function dodajTim(tim) {
        const odgovor = await TimService.dodajTim(tim);
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
        //console.log(podaci.get('ime_tima'));

        const tim =
        {
            ime_tima: podaci.get('ime_tima'),
            drzava_sjedista: podaci.get('drzava_sjedista'),
            godina_osnutka: parseInt(podaci.get('godina_osnutka'))
        };
        //console.log(JSON.stringify(tim));
        dodajTim(tim);
    }

    return (
        <Container>
            <Form onSubmit={handleSubmit}>

                <Form.Group controlId="ime_tima">
                    <Form.Label>Ime tima</Form.Label>
                    <Form.Control
                        type="text"
                        name="ime_tima"
                    />
                </Form.Group>

                <Form.Group controlId="drzava_sjedista">
                    <Form.Label>Država sjedišta</Form.Label>
                    <Form.Control
                        type="text"
                        name="drzava_sjedista"
                    />
                </Form.Group>

                <Form.Group controlId="godina_osnutka">
                    <Form.Label>Godina osnutka</Form.Label>
                    <Form.Control
                        type="text"
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
                            Dodaj smjer
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>
    );
}