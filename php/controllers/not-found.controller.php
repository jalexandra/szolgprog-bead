<?php
http_response_code(404);
echo json_encode(['error' => "Unknown model {$_GET['m']}"]);