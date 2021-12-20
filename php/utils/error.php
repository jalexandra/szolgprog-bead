<?php

function passId(callable $callable): string {
    if($_GET['id']){
        return $callable($_GET['id']);
    }

    http_send_status(400);
    return json_encode(['error' => 'Parameter "id" was missing from query string']);

}
