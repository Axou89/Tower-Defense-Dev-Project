from fastapi import FastAPI

app = FastAPI()

@app.get("/F1")
def Hello(name : str):
    return {"Hello " + name}
