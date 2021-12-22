<?php
if(!isset($_GET['m'])){
    $_GET['m'] = '';
}
if(!isset($_GET['v'])){
    $_GET['v'] = 'get';
}
if (!isset($_GET['id'])){
    $_GET['id'] = '';
}
switch ($_GET['m']) {
    case 'user':
        require_once 'controllers/user.controller.php';
        break;
    default:
        require_once 'controllers/not-found.controller.php';
}