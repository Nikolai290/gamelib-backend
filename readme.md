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

Go to URL http://localhost:1984/swagger\
Run any http request for initial database. \
Try create, update or delete some entries through REST API.

For check database open Adminer on http://localhost:8181\
And use credentials from docker-compose file.
