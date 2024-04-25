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

export default {
    getTimovi
};