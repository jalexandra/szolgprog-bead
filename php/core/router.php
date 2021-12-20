<?php
switch ($_GET['m']) {
    case 'user':
        require_once '../controllers/user.controller.php';
        break;
    default:
        require_once '../controllers/not-found.controller.php';
}