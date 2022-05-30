### Test task "Game Library"

Backend for app, have 3 REST API Controllers for next entities:

- Company
- Genre
- Game

Base on onion architecture devided on different layers with dependencies inversion.

Run script

```Bash
git clone https://github.com/Nikolai290/gamelib-backend
cd gamelib-backend
docker-compose up
```

Pass environment variable BASE_INIT_DATABASE with value "true" for backend <br/>
for base init database while any http request if database is empty.

Go to URL http://localhost:1984/swagger <br/>
Try create, update or delete some entries through REST API.

For check database open Adminer on http://localhost:8181 <br/>
And use credentials from docker-compose file.
