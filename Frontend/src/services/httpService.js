import axios from "axios";

export const httpService = axios.create({
    baseURL: 'https://mkesinovi-001-site1.ctempurl.com/api/v1',
    headers: {
        'Content-Type': 'application/json'
    }
});