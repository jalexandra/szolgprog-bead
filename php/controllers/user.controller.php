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
    case 'delete': {
        passId('deleteUser');
    }
}

function browseUsers(): string
{
    return '';
}

function readUser(int $id): string
{
    return '';
}

function editUser(int $id): string
{
    return '';
}

