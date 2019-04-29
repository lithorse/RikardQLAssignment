<template>
  <div>
      <div class="buttons">
        <button class="button is-medium" @click="getMarkers">Read</button>
        <button class="button is-medium" @click="clearMarkers">Clear</button>
        <button class="button is-medium" @click="getCurrentLocation">My Position</button>
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
        counter: 0,
        urlAppend: ''
      }
  },
  methods: {
      getMarkers(){
            this.counter++;
            this.urlAppend = '';
            if(this.counter % 3 == 0){
                this.urlAppend = 'circle';
            }
            positionService.getPositions(this.urlAppend).then(data => {
                this.setMarkers(data);
            });
        },
      setMarkers(data){
            this.markers = [];
            data.forEach(position => {
                this.addMarker({position: { lat: parseFloat(position.latitude), lng: parseFloat(position.longitude) }, title: position.title})
            });
            this.setMapBounds();
      },
      addMarker(marker){
        this.markers.push(marker)
      },
      clearMarkers(){
          this.markers = []
      },
      getCurrentLocation(){
        var self = this;
        if (navigator.geolocation){
          navigator.geolocation.getCurrentPosition(function(position) {
            self.addMarker({
              position: { lat: position.coords.latitude, lng: position.coords.longitude }, 
              title: 'lat: ' + position.coords.latitude + ' lng: ' + position.coords.longitude
            })
            self.setMapBounds();
          }, 
          function() {
            handleLocationError(true);
          });
        } 
        else {
          handleLocationError(false);
        }
      },
      handleLocationError(browserHasGeolocation) {
        browserHasGeolocation ? console.log('Error: The Geolocation service failed.') : console.log('Error: Your browser doesn\'t support geolocation.');
      },
      setMapBounds(){
        this.$refs.gmap.$mapPromise.then((map) => {
          const bounds = new google.maps.LatLngBounds()
          for (let m of this.markers) {
            bounds.extend(m.position)
          }
          map.fitBounds(bounds);
        });
      }
  }
}
</script>