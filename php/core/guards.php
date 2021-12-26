<?php

function getUserFromApiKey() {
    $headers = getallheaders();
    if(!isset($headers['X-API-KEY'])){
        return false;
    }
    $apiKey = $headers['X-API-KEY'];
    if(!$apiKey) {
        return false;
    }

    $result = DB::query('SELECT * FROM users WHERE api_key = :apiKey', ['apiKey' => $apiKey]);
    if(count($result) === 0) {
        return false;
    }
    return $result[0];
}

function usersOnly() {
    $user = getUserFromApiKey();
    if(!$user) {
        Response::unauthenticated();
    }
    return $user;
}

function adminOnly() {
    usersOnly();
    $user = getUserFromApiKey();

    /** @noinspection TypeUnsafeComparisonInspection */
    if($user['is_admin'] !== 1) {
        Response::forbidden();
    }

    return $user;
}