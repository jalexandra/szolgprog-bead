<?php

class Validation
{
    public static function isset(array $fields): string
    {
        foreach ($fields as $field) {
            if(!isset($_POST[$field])){
                return "$field is required";
            }
        }
        return '';
    }
}