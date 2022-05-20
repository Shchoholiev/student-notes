import { Group } from "./group.model";

export class User {
    id: number = 0;
    name: string = "";
    email: string = "";
    avatar: string = "";
    group: Group = new Group();
}
