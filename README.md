# Programação para Internet 2

- [Rest API (ASP.NET 6)](#rest-api)
    - [Auth](#auth)
        - [SignUp](#Signup)
            - [SignUp Request](#Signup-request)
            - [SignUp Response](#Signup-response)
        - [SignIn](#Signin)
            - [SignIn Request](#Signin-request)
            - [SignIn Response](#Signin-response)

## Auth

### SignUp

```js
POST {{host}}/auth/SignUp
```

#### SignUp Request

```json
{
    "firstName": "Foo",
    "lastName": "Bar",
    "email": "foobar@email.com",
    "password": "Passwd#FooBar42",
}
```

#### SignUp Response

```js
200 OK
```

```json
{
    "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
    "firstName": "Foo",
    "lastName": "Bar",
    "email": "foobar@email.com",
    "password": "Passwd#FooBar42",
    "token": "eyJhb..hbbQ"
}
```

### SignIn

```js
POST {{host}}/auth/SignIn
```

#### SignIn Request

```json
{        
    "email": "Foo@Bar.com",
    "password": "Passwd#FooBar42",    
}
```

#### SignIn Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Foo",
  "lastName": "Bar",
  "email": "foobar@email.com",
  "token": "eyJhb..hbbQ"
}
```
