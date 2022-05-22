import { NoteBase } from "./note-base.model";

export class TextNote extends NoteBase {
    name: string = "";
    text: string = "";

    constructor(name: string, text: string){
        super();
        this.name = name;
        this.text = text;
    }
}
