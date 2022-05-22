import { File } from "./file.model";
import { NoteBase } from "./note-base.model";

export class FileNote extends NoteBase {
    files: File[] = [];

    constructor(files: File[]){
        super();
        this.files = files;
    }
}
