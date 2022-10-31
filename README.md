# TodoApi 

 This Api provides back-end for Todo notes application. User required to be authorized befor user can call api.:bowtie:
 
 Clone the repository to your local machine. 
 https://github.com/dwarfsuomalainen/TodoApi.git
 
 You need Doker Desktop to be installed to start up the project. 
 Check docker-compose.yml and make desirable changes in database settings.
 Use 
 * docker-compose up -d 
 (to set up volumes in docker. 
 If no changes needed, use current settings.) 
 Go to 
 * http://localhost:5050/login 
 Use the credentials from docker-compose.yml
 * email : r.bogoudinov@mac.com
 * password : admin1234
 Register a server in pgAdmin
 Connection settings:
 * Hostname/address: postgresql_database
 * Port: 5432
 * Maintanance database: todoDb
 * Username: admin
 * Password: roma1234
 
 ![Screenshot 2022-10-30 at 20 20 02](https://user-images.githubusercontent.com/73884598/198894961-8b381127-dc21-4652-9022-163839d3da55.png)
 
 After setting up the database, use the command 
 dotnet ef database update 
 It will add Todos and Users tables according the Migrations. 
 
 You all set now. Hit F5 and start the project.
 go to newly opened tab in your browser and add /swagger to the adddress.
 
 In th swagger UI you can tes the api. 
 
 First SignUp
 
 Change request json body, or leave it as it apeeared (this is okay for testing) then hit Execute.
 ![Screenshot 2022-10-30 at 20 40 07](https://user-images.githubusercontent.com/73884598/198895972-87306eb3-ac84-4e5f-9ab6-3c7730832555.png)
 
 Now you need to Sign in, because there is no unauthorized access to view the Todos.
 
 SignIn
 
 Change request json body, if you changed it in SignUp or leave it as it appeared.
 
 Copy the Response body, here is a token you need to for authorization.
 
 ![Screenshot 2022-10-30 at 20 45 58](https://user-images.githubusercontent.com/73884598/198896076-fbe11f44-f990-4cd0-b51e-22f2de1ed5fc.png)

 Then go up at this page and hit Authorize button at the upper right corner. 
 
 In the Value field type first Bearer 
 
 ![Screenshot 2022-10-30 at 20 52 04](https://user-images.githubusercontent.com/73884598/198896284-b8ffd1e4-e0b9-4971-bb57-f80beea376bd.png)
 
 after Bearer word, type space and add the token you copied on the step above.
 
 ![Screenshot 2022-10-30 at 20 54 44](https://user-images.githubusercontent.com/73884598/198896406-181dcb55-6cdf-4476-a13f-9aec89be456a.png)
 
 ![Screenshot 2022-10-30 at 20 55 15](https://user-images.githubusercontent.com/73884598/198896445-13932549-9c6f-442e-abd9-0f1ff7d6322d.png)
 
 Create a Todo note 

 
 
 Get Todos 
 
 In the response body you can see the todo you just posted on the previous step. 
 
 ![Screenshot 2022-10-30 at 21 24 16](https://user-images.githubusercontent.com/73884598/198897601-8ebdae4f-1c6a-425f-9076-a99892c39835.png)

 As you see, there is a sorting by Status implemented in the project. 
 
 ![Screenshot 2022-10-30 at 21 26 47](https://user-images.githubusercontent.com/73884598/198897733-5406e55a-a028-44c2-a7e2-41dced7a454b.png)

 Edit a Todo
 
 ![Screenshot 2022-10-30 at 22 02 46](https://user-images.githubusercontent.com/73884598/198899194-fd85269c-c351-41cc-8983-780f9223e172.png)
 and check the changes 
 ![Screenshot 2022-10-30 at 22 03 56](https://user-images.githubusercontent.com/73884598/198899246-0a37cf88-a4a6-49b4-8255-750a2d4e7c07.png)

 Deleting Todo
 
 ![Screenshot 2022-10-30 at 22 06 59](https://user-images.githubusercontent.com/73884598/198899360-afc890e4-769b-4566-a258-3697d31e0605.png)
 
 and check it was deleted, now api returns empty array, because only object you created now deleted. 
 
 ![Screenshot 2022-10-30 at 22 07 50](https://user-images.githubusercontent.com/73884598/198899414-e67bfffb-1301-4e6b-b48f-f5c9373d3e10.png)

 Changing a password 
 
 ![Screenshot 2022-10-30 at 22 01 45](https://user-images.githubusercontent.com/73884598/198899130-1cc7f220-7f67-4dd8-a34a-b44a215752af.png)

 Unathorized user can not see Todos. 
 All the exceptions are standart, custom exceptions will be created in future versions of API.
 
 
 
