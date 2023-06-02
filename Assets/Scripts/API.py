from fastapi import FastAPI

app = FastAPI()

@app.get("/Playerid")
def Hello(ud : str):
    return {"Hello " + name}
