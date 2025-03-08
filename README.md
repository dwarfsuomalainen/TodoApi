# TodoAPI

TodoAPI provides the backend for a Todo application. Users must be signed in to access the API.

## C# and .NET Core for Web Development Assignment

### Clone the Repository

Clone the repository to your local machine:

```
git clone https://github.com/dwarfsuomalainen/TodoApi.git
```

### Prerequisites

You need **Docker Desktop** installed to start the project.

- Check `docker-compose.yml` and modify database settings if needed.

### Starting the Project

Run the following command to set up volumes in Docker:

```
docker-compose up -d
```

If no changes are needed, use the default settings.

### Access the Application

Go to:

```
http://localhost:5050/login
```

Use the credentials from `docker-compose.yml`:

- **Email**: `r.bogoudinov@mac.com`
- **Password**: `admin1234`

### Register a Server in pgAdmin

#### Connection Settings:

- **Hostname/address**: `postgresql_database`
- **Port**: `5432`
- **Maintenance Database**: `todoDb`
- **Username**: `admin`
- **Password**: `roma1234`

![Database Setup](https://user-images.githubusercontent.com/73884598/198894961-8b381127-dc21-4652-9022-163839d3da55.png)

After setting up the database, run:

```
dotnet ef database update
```

This will create `Todos` and `Users` tables according to migrations.

### Running the Project

Press **F5** to start the project.  
Once the browser tab opens, append `/swagger` to the address to access Swagger UI.

## Using the API

### Sign Up

Modify the request JSON body if needed, or leave it as default for testing. Then, click **Execute**.

![Sign Up](https://user-images.githubusercontent.com/73884598/198895972-87306eb3-ac84-4e5f-9ab6-3c7730832555.png)

### Sign In

Use the same credentials as in Sign Up. Copy the **token** from the response body.

![Sign In](https://user-images.githubusercontent.com/73884598/198896076-fbe11f44-f990-4cd0-b51e-22f2de1ed5fc.png)

### Authorization

Click the **Authorize** button (upper-right corner).  
Enter the token in the format:

```
Bearer <your-token>
```

![Authorize](https://user-images.githubusercontent.com/73884598/198896284-b8ffd1e4-e0b9-4971-bb57-f80beea376bd.png)

### Create a Todo Note

![Create Todo](https://user-images.githubusercontent.com/73884598/199000044-387d33a9-c687-40da-94d3-821672fbee5f.png)

### Get Todos

Check the response body to see the Todo you just created.

![Get Todos](https://user-images.githubusercontent.com/73884598/198897601-8ebdae4f-1c6a-425f-9076-a99892c39835.png)

The project implements sorting by status.

![Sorting](https://user-images.githubusercontent.com/73884598/198897733-5406e55a-a028-44c2-a7e2-41dced7a454b.png)

### Edit a Todo

![Edit Todo](https://user-images.githubusercontent.com/73884598/198899194-fd85269c-c351-41cc-8983-780f9223e172.png)

Check the changes:

![Check Edit](https://user-images.githubusercontent.com/73884598/198899246-0a37cf88-a4a6-49b4-8255-750a2d4e7c07.png)

### Delete a Todo

![Delete Todo](https://user-images.githubusercontent.com/73884598/198899360-afc890e4-769b-4566-a258-3697d31e0605.png)

Confirm deletion—API should now return an empty array.

![Check Deletion](https://user-images.githubusercontent.com/73884598/198899414-e67bfffb-1301-4e6b-b48f-f5c9373d3e10.png)

### Change Password

![Change Password](https://user-images.githubusercontent.com/73884598/198899130-1cc7f220-7f67-4dd8-a34a-b44a215752af.png)

### Unauthorized Access

Unauthorized users **cannot** access Todos.  
All exceptions are standard; custom exceptions will be implemented in future versions.
