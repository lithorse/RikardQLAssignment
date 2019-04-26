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
Mandatory requirements
1. Pressing the READ button should read a number of coordinates from the server-side code and display the
coordinates as pins on the world map. The pins are labeled with text stored with the coordinates.
2. Pressing CLEAR should remove the pins from the map.
3. The coordinates should consist of latitude, longitude and a short text (15 characters) stored in the contained
database or file.
4. The HTML file should reference at least one JavaScript file and one CSS file.
5. No Postbacks should be made.
6. Every third time the READ button is pressed a (one) the coordinates retrieved from the backend should form
a mathematical pattern and be displayed on the map
