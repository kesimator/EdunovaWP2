import { App } from "../constants"
import { httpService } from "./httpService";

async function getSmjerovi(sifra) {
    return await httpService.get('/Smjer')
        .then((res) => {
            if (App.DEV) console.table(res);
            return res;
        }).catch((e) => {
            console.log(e);
        });
}

export default {
    getSmjerovi
};