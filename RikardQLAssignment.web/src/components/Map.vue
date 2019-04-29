<template>
  <div>
      <div class="buttons">
        <button class="button is-medium" @click="getMarkers">Read</button>
        <button class="button is-medium" @click="clearMarkers">Clear</button>
        <button class="button is-medium" @click="getCurrentLocation">My Position</button>
        <div class="field"> 
          <label class="label">Latitude</label>
          <input class="input" placeholder="Latitude" v-model="inputLat">
          <label class="label">Longitude</label>
          <input class="input" placeholder="Longitude" v-model="inputLng">
        </div>
        <button class="button is-medium" @click="setCustomMarker(inputLat, inputLng)">Set Marker</button>
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
        urlAppend: '',
        inputLat: null,
        inputLng: null
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
                this.addMarker(parseFloat(position.latitude), parseFloat(position.longitude), position.title)
            });
            this.setMapBounds();
      },
      addMarker(latitude, longitude, title){
        var marker = {position: { lat: latitude, lng: longitude }, title: title}
        this.markers.push(marker)
      },
      clearMarkers(){
          this.markers = []
      },
      getCurrentLocation(){
        var self = this;
        if (navigator.geolocation){
          navigator.geolocation.getCurrentPosition(function(position) {
            self.addMarker(position.coords.latitude, position.coords.longitude, 'Latitude: ' + position.coords.latitude + ' Longitude: ' + position.coords.longitude)
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
      },
      setCustomMarker(latitude, longitude){
        this.addMarker(parseFloat(latitude), parseFloat(longitude), 'Latitude: ' + latitude + ' Longitude: ' + longitude)
        this.setMapBounds()
      }
  }
}
</script>