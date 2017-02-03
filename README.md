# emotionRESTApi
Wrapper for the microsoft emotionAPI that you can call with an image url

#IN EARLY DEVELOPMENT

#Use with Postman
Use a tool like postman to post to API
For example
Endpoint - http://localhost:1673/api/image
Use Body>Raw>JSON(application/json) and then in the body the image url in speach marks

POST /api/image HTTP/1.1
Host: localhost:1673
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: fd311cfa-c493-ad01-fd36-e46e83aa7a95
"http://cola.unh.edu/sites/cola.unh.edu/files/styles/homepage/public/images/homepagePhotoFRLrev.jpg?itok=wdJ0UxSm"
