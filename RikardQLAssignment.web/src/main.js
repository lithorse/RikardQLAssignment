import Vue from 'vue'
import App from './App.vue'
import * as VueGoogleMaps from 'vue2-google-maps'
import Axios from 'axios';

Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyCfDeFvq16sqrmyRSWzcvBHoQtEpsGNVOE',
    libraries: 'places'
  }
})

require("./assets/main.scss")

console.log("Using baseURL: " + process.env.VUE_APP_ROOT_API); 
Axios.defaults.baseURL = process.env.VUE_APP_ROOT_API;

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
