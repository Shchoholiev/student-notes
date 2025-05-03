import { Teacher } from "./teacher.model";

export class Subject {
    id: number = 0;
    name: string = "";
    teacher: Teacher = new Teacher();
}
