import axios from "axios"

export default {
    async getTime() {
        return await axios.get('http://localhost:5000/BerlinClock');
    }
}