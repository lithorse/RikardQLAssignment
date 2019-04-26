import axios from 'axios';

function getPositions(){
    var positions = axios.get('https://localhost:8080/api/position/').catch(e => console.log(e));
    return positions;
}