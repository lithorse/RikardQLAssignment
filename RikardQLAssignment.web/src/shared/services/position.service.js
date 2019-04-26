import axios from 'axios';

function getPositions(urlAppend = ''){
    return axios.get('http://localhost:65013/api/position/' + urlAppend).then(response => { return response.data }).catch(e => console.log(e));
}

export const positionService = { getPositions };