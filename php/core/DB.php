<?php

class DB
{
    private PDO $pdo;

    public function __construct()
    {
        $this->pdo = new PDO(
            'mysql:host=' . DB_HOST . ';dbname=' . DB_NAME . ';charset=utf8mb4',
            DB_USER,
            DB_PASSWORD,
            [
                PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
                PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
                PDO::ATTR_EMULATE_PREPARES   => false,
            ]
        );
    }

    public function query(string $sql, array $parameters = []) {
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute($parameters);
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function execute(string $sql, array $parameters = []) {
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute($parameters);
        return $stmt->rowCount();
    }
}