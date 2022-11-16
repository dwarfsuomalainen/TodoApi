# TodoAPI
TodoAPI provides back-end for Todo application. It requires users to be signed in to be able call the API.

 <h2>C# and .NET core for Web development assignment </h2>
 
 <h3>Clone the repository to your local machine. </h3>
 <ul>https://github.com/dwarfsuomalainen/TodoApi.git</ul>
 
 <h3>You need Doker Desktop to be installed to start up the project. </h3>
 <h4>Check docker-compose.yml and make desirable changes in database settings.</h4>
 <h3>Use</h3> 
 <ul><p>docker-compose up -d (to set up volumes in docker.)</p> 
 <p>If no changes needed, use current settings.</p> </ul> 
 <h3>Go to </h3>  
 <ul>
 <p>http://localhost:5050/login </p>
 <p>Use the credentials from docker-compose.yml</p>
 <li>email : r.bogoudinov@mac.com</li>
 <li>password : admin1234</li>
 </ol>
 <h3>Register a server in pgAdmin</h3>
 <ol>
 <p>Connection settings:</p>
 <li>Hostname/address: postgresql_database</li>
 <li>Port: 5432</li>
 <li>Maintanance database: todoDb</li>
 <li>Username: admin</li>
 <li>Password: roma1234</li>
 </ol>
 
 ![Screenshot 2022-10-30 at 20 20 02](https://user-images.githubusercontent.com/73884598/198894961-8b381127-dc21-4652-9022-163839d3da55.png)
 
 <p>After setting up the database, use the command 
 dotnet ef database update 
 It will add Todos and Users tables according the Migrations. 
 
 You all set now. Hit F5 and start the project.
 go to newly opened tab in your browser and add /swagger to the adddress.
 
 In th swagger UI you can tes the api. </p>
 
 <h3>First SignUp</h3>
 
 <p>Change request json body, or leave it as it apeeared (this is okay for testing) then hit Execute.</p>
 
 ![Screenshot 2022-10-30 at 20 40 07](https://user-images.githubusercontent.com/73884598/198895972-87306eb3-ac84-4e5f-9ab6-3c7730832555.png)
 
 <p>Now you need to Sign in, because there is no unauthorized access to view the Todos.</p>
 
 <h3>SignIn<h3>
 
 <p>Change request json body, if you changed it in SignUp or leave it as it appeared.
 
 Copy the Response body, here is a token you need to for authorization.</p>
 
 ![Screenshot 2022-10-30 at 20 45 58](https://user-images.githubusercontent.com/73884598/198896076-fbe11f44-f990-4cd0-b51e-22f2de1ed5fc.png)

 <p>Then go up at this page and hit Authorize button at the upper right corner. 
 
 In the Value field type first Bearer </p>
 
 ![Screenshot 2022-10-30 at 20 52 04](https://user-images.githubusercontent.com/73884598/198896284-b8ffd1e4-e0b9-4971-bb57-f80beea376bd.png)
 
 <p>after Bearer word, type space and add the token you copied on the step above.</p>
 
 ![Screenshot 2022-10-30 at 20 54 44](https://user-images.githubusercontent.com/73884598/198896406-181dcb55-6cdf-4476-a13f-9aec89be456a.png)
 
 ![Screenshot 2022-10-30 at 20 55 15](https://user-images.githubusercontent.com/73884598/198896445-13932549-9c6f-442e-abd9-0f1ff7d6322d.png)
 
 <h3>Create a Todo note </h3>

 ![Screenshot 2022-10-30 at 21 55 14](https://user-images.githubusercontent.com/73884598/199000044-387d33a9-c687-40da-94d3-821672fbee5f.png)
 
 <h3>Get Todos</h3> 
 
 <p>In the response body you can see the todo you just posted on the previous step. </p>
 
 ![Screenshot 2022-10-30 at 21 24 16](https://user-images.githubusercontent.com/73884598/198897601-8ebdae4f-1c6a-425f-9076-a99892c39835.png)

 <p>As you see, there is a sorting by Status implemented in the project. </p>
 
 ![Screenshot 2022-10-30 at 21 26 47](https://user-images.githubusercontent.com/73884598/198897733-5406e55a-a028-44c2-a7e2-41dced7a454b.png)

 <h3>Edit a Todo</h3>
 
 ![Screenshot 2022-10-30 at 22 02 46](https://user-images.githubusercontent.com/73884598/198899194-fd85269c-c351-41cc-8983-780f9223e172.png)
 
 <p>and check the changes </p>
 
 ![Screenshot 2022-10-30 at 22 03 56](https://user-images.githubusercontent.com/73884598/198899246-0a37cf88-a4a6-49b4-8255-750a2d4e7c07.png)

 <h3>Deleting Todo </h3>
 
 ![Screenshot 2022-10-30 at 22 06 59](https://user-images.githubusercontent.com/73884598/198899360-afc890e4-769b-4566-a258-3697d31e0605.png)
 
 <p>and check it was deleted, now api returns empty array, because only object you created now deleted. </p>
 
 ![Screenshot 2022-10-30 at 22 07 50](https://user-images.githubusercontent.com/73884598/198899414-e67bfffb-1301-4e6b-b48f-f5c9373d3e10.png)

 <h3>Changing a password </h3>
 
 ![Screenshot 2022-10-30 at 22 01 45](https://user-images.githubusercontent.com/73884598/198899130-1cc7f220-7f67-4dd8-a34a-b44a215752af.png)

 <p>Unathorized user can not see Todos. 
 All the exceptions are standart, custom exceptions will be created in future versions of API.</p>
 
 
 
