export class File {
    id: number = 0;
    name: string = "";
    link: string = "";

    constructor(name: string, link: string){
        this.name = name;
        this.link = link;
    }
}
