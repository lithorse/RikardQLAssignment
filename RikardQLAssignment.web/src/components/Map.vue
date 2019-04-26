<template>
  <div>
      <div class="buttons">
        <button class="button is-medium" @click="getMarkers">Read</button>
        <button class="button is-medium" @click="clearMarkers">Clear</button>
      </div>
    <GmapMap ref="gmap" :center="center" :zoom="3" map-type-id="hybrid" style="width: 100%; height: 100vh" :options="{fullscreenControl: false, streetViewControl: false, mapTypeControl: false}">
        <GmapMarker :key="index" v-for="(m, index) in markers" :position="m.position" :title="m.title" :clickable="true" @click="center=m.position"/>
    </GmapMap>
  </div>
</template>

<script>
import {positionService} from '../shared/services'
export default {
  name: 'Map',
  data(){
      return {
        center: { lat: 0, lng: 0 },
        markers: [],
        counter: 0
      }
  },
  methods: {
      getMarkers(){
          this.counter++;
          if(this.counter % 3 == 0){
              positionService.getPositions('circle').then(data => {
                this.setMarkers(data);
            });
          }
          else{
            positionService.getPositions().then(data => {
                this.setMarkers(data);
            });
          }
      },
      setMarkers(data){
            this.markers = [];
            data.forEach(position => {
                this.markers.push({position: { lat: parseFloat(position.latitude), lng: parseFloat(position.longitude) }, title: position.title})
            });
            this.$refs.gmap.$mapPromise.then((map) => {
                const bounds = new google.maps.LatLngBounds()
                for (let m of this.markers) {
                    bounds.extend(m.position)
                }
                map.fitBounds(bounds);
            });
      },
      clearMarkers(){
          this.markers = []
      }
  }
}
</script>