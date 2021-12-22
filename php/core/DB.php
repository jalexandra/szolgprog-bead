<?php

DB::init();

class DB
{
    private static PDO $pdo;

    public static function init(): void
    {
        try {
            self::$pdo = new PDO(
                'mysql:host=' . DB_HOST . ';dbname=' . DB_NAME . ';charset=utf8mb4',
                DB_USER,
                DB_PASSWORD,
                [
                    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
                    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
                    PDO::ATTR_EMULATE_PREPARES   => false,
                ]
            );
            self::$pdo->query('SELECT 1')->fetchAll(); // SQL self test
        } catch (PDOException) {
            Response::serverError('MySQL server is down');
        }
    }

    public static function query(string $sql, array $parameters = []): bool|array
    {
        $stmt = self::$pdo->prepare($sql);
        $stmt->execute($parameters);
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public static function execute(string $sql, array $parameters = []): int
    {
        $stmt = self::$pdo->prepare($sql);
        $stmt->execute($parameters);
        return $stmt->rowCount();
    }
}