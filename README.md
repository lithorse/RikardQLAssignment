# RikardQLAssignment

Use any of the following technologies to implement the UI: ASP.NET MVC, Angular, Vue.js, ReactJS. Use either node.js,
.NET 4.5+ (full framework) or .NET Core to implement the backend as a Web API.
Use JavaScript or C# as server language and JavaScript as client language. Any additional third-party framework may
be used on the client side. On the server-side no third-party framework should be necessary. Data will be stored either
in an MSSQL (express) database, MongoDB or DocumentDB - or read from a file on disk using an appropriate Reader
(imagine that the data set would be much larger than it actually is in this assignment). Include setup instructions for
the data source.
Assignment
Implement a GUI containing 1 world map and 2 buttons – READ and CLEAR.

Technologies used  
Backend: .NET Core 2.2 and Web API  
Frontend: Vue.js  
Map: Google Maps

Mandatory requirements
1. Pressing the READ button should read a number of coordinates from the server-side code and display the
coordinates as pins on the world map. The pins are labeled with text stored with the coordinates.  
**Solution:** Pressing the Read button gets a set of Position objects containing coordinates from a .NET Core based API. These are converted to Google Maps API compatible markers and displayed on the map. A label is shown with the markers when hovered over.

2. Pressing CLEAR should remove the pins from the map.  
**Solution:** Pressing the Clear button clears the list of markers to display.

3. The coordinates should consist of latitude, longitude and a short text (15 characters) stored in the contained
database or file.  
**Solution:** The Position object contains latitude, longitude and a title stored in a SQL database

4. The HTML file should reference at least one JavaScript file and one CSS file.  
**Solution:** Frontend built with Vue references several .js files and one .scss file.

5. No Postbacks should be made.  
**Solution:** No postbacks are made.

6. Every third time the READ button is pressed a (one) the coordinates retrieved from the backend should form
a mathematical pattern and be displayed on the map  
**Solution:** Every third time the Read button is pressed a different route is called on the API to get a set of markers that form a circle.

Optional requirements

7. Add an additional button MY LOCATION that uses the browser geoLocation to place an additional pin on the
map presenting your current position.  
**Solution:** Pressing the My Location button gets the Geolocation of the browser and places a marker on the map at that position.

8. Add the possibility to input latitude and longitude on the client and a button to place a marker on that location
on the map  
**Solution:** Two fields to input latitude and longitude and a button labeled Set Marker to add a marker at the specified coordinates.

9. Make the world map stretch horizontally to always have 100% width of the viewport and make it respond to
resizing the browser window.  
**Solution:** World map width is always 100% width of viewport.

10. Structure your solution so that appropriate layers may reside on different server machines.

11. Invoke server-side methods asynchronously.

12. Integrate a DI framework of your own choice  
**Solution:** Makes use of the Asp.net core DI framework
