import axios from 'axios';

function getPositions(urlAppend = ''){
    return axios.get(process.env.VUE_APP_ROOT_API + 'position/' + urlAppend).then(response => { return response.data }).catch(e => console.log(e));
}

export const positionService = { getPositions };