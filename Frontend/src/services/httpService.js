import axios from "axios";

export const httpService = axios.create({
    baseURL: 'https://mkesinov-001-site1.anytempurl.com/api/v1',
    headers: {
        'Content-Type': 'application/json'
    }
});