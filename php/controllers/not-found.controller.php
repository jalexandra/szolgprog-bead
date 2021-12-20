<?php
http_send_status(404);
echo json_encode(['error' => "Unknown model {$_GET['m']}"]);