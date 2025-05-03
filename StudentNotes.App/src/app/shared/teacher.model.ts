import { Subject } from "./subject.model";

export class Teacher {
    id: number = 0;
    name: string = "";
    email: string = "";
    avatar: string = "";
    subjects: Subject[] = [];
}
