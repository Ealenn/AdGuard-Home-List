const express = require('express');
const app = express();

/**
 * Middleware
 */
app.disable('x-powered-by');

/**
 * Route
 */
app.use(express.static('dist'));

/**
 * Serve
 */
app.listen(process.env.PORT || 3000);
