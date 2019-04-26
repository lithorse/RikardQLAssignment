import Vue from 'vue'
import App from './App.vue'
import * as index from './shared/services/index';
import * as VueGoogleMaps from 'vue2-google-maps'

Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyCfDeFvq16sqrmyRSWzcvBHoQtEpsGNVOE',
    libraries: 'places'
  }
})

Vue.use(index);

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
