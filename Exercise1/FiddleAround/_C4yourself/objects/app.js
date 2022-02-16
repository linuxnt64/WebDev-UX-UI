
/* ---- Don't change anything between here --- */

const teacher = {
    name: 'Max',
    age: 31,
    boring: 'Sometimes',
    fun: true,
    weSolvedIt: true
};

function pupil(name) {
    document.querySelector("p").innerHTML='... has pupil named ' + name;
}

for (const [key, value] of Object.entries(teacher))
document.querySelector("h1").innerHTML+=key+" : "+`${value}<br>`

pupil('Staffan');