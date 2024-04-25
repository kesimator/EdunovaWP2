import { App } from "../constants"
import { httpService } from "./httpService";

async function getTimovi() {
    return await httpService.get('/Tim')
        .then((res) => {
            if (App.DEV) console.table(res.data);
            return res;
        }).catch((e) => {
            console.log(e);
        });
}

async function obrisiTim(id) {
    return await httpService.delete('/Tim/' + id)
        .then((res) => {
            return { ok: true, poruka: res };
        }).catch((e) => {
            console.log(e);
        });
}

async function dodajTim(tim) {
    const odgovor = await httpService.post('/Tim', tim)
        .then(() => {
            return { ok: true, poruka: 'Uspješno dodano' }
        })
        .catch((e) => {
            console.log(e.response.data.errors);
            return { ok: false, poruka: 'Greška' }
        });
    return odgovor;
}

async function promijeniTim(id, tim) {
    const odgovor = await httpService.put('/Tim/' + id, tim)
        .then(() => {
            return { ok: true, poruka: 'Uspješno promijenjeno' }
        })
        .catch((e) => {
            console.log(e.response.data.errors);
            return { ok: false, poruka: 'Greška' }
        });
    return odgovor;
}

async function getById(id) {
    return await httpService.get('/Tim/' + id)
        .then((res) => {
            if (App.DEV) console.table(res.data);
            return res;
        }).catch((e) => {
            console.log(e);
            return { poruka: e }
        });
}

export default {
    getTimovi,
    obrisiTim,
    dodajTim,
    promijeniTim,
    getById
};