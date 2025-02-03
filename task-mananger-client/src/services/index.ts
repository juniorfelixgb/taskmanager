import axios from "axios";

const BASE_URL = "http://localhost:5242/api";

const instance = axios.create({
    url: BASE_URL
});

export default instance;