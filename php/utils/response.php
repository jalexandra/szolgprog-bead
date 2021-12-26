<?php
class Response {
    public static function noContent(): string
    {
        http_response_code(204);
        return ' ';
    }

    public static function unauthenticated(): void
    {
        self::abort(401, 'API key was not present in header');
    }

    public static function forbidden(): void
    {
        self::abort(403, 'This user does not have the necessary permission for this operation');
    }

    public static function notFound(): void
    {
        self::abort(404, 'This model does not exist');
    }

    public static function badRequest(string $message): void
    {
        self::abort(400, $message);
    }

    public static function created(): string
    {
        http_response_code(201);
        return '';
    }

    public static function serverError(string $message): void
    {
        self::abort(500, $message);
    }

    public static function abort(int $code, string $message): void
    {
        http_response_code($code);
        header('Content-Type: application/json; charset=utf-8');
        die(json_encode(['error' => $message]));
    }
}