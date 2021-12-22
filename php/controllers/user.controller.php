<?php
switch ($_GET['v']) {
    case 'get':
        if($_GET['id']) {
            echo readUser($_GET['id']);
        }
        else {
            echo browseUsers();
        }
        break;
    case 'patch':
        passId('editUser');
        break;
    case 'post':
        echo addUser();
        break;
    case 'delete': {
        passId('deleteUser');
    }
}

function browseUsers(): string
{
    adminOnly();
    $users = DB::query('SELECT id, name, phone, email, is_admin FROM users WHERE 1');

    return json_encode($users);
}

function readUser(int $id): string
{
    adminOnly();
    $res = DB::query('SELECT id, name, phone, email, is_admin FROM users WHERE id=:id', ['id' => $id]);
    if(!count($res)) {
        Response::notFound();
    }
    return json_encode($res);
}

function editUser(int $id): string
{
    adminOnly();

    $params = ['id' => $id];
    $query = 'UPDATE users SET';
    foreach($_POST as $key => $value) {
        $query .= " $key=:$key,";
        $params[$key] = $value;
    }
    $query = rtrim($query, ',');
    $query .= ' WHERE id=:id';
    $res = DB::execute($query, $params);

    if(!$res) {
        Response::notFound();
    }

    return Response::noContent();
}

function addUser(): string
{
    adminOnly();

    $missing = Validation::isset([
        'name',
        'email',
        'password',
        'password_confirmation',
    ]);
    if($missing !== ''){
        Response::badRequest($missing);
    }

    if($_POST['password'] !== $_POST['password_confirmation']){
        Response::badRequest('Password and Password Confirmation do not match');
    }

    if(!isset($_POST['phone'])){
        $_POST['phone'] = '';
    }

    try {
        DB::execute(
            'INSERT INTO users(name, password, email, api_key, phone) VALUES (:name, :password, :email, :apiKey, :phone);',
            [
                'name' => $_POST['name'],
                'password' => password_hash($_POST['password'], PASSWORD_BCRYPT),
                'email' => $_POST['email'],
                'apiKey' => uniqid('', true),
                'phone' => $_POST['phone']
            ]
        );
    } catch (PDOException){
        Response::badRequest('Email already exists');
    }

    return Response::created();
}

function deleteUser(int $id): string
{
    adminOnly();

    $res = DB::execute('DELETE FROM users WHERE id=:id', ['id' => $id]);
    if (!$res) {
        Response::notFound();
    }

    return Response::noContent();
}