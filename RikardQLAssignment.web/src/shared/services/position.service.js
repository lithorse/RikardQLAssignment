import axios from 'axios';

function getPositions(){
    return axios.get('http://localhost:65013/api/position').then(response => { return response.data }).catch(e => console.log(e));
}

export const positionService = { getPositions };