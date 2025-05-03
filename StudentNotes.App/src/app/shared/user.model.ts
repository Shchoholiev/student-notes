import { Group } from "./group.model";
import { Role } from "./role.model";

export class User {
    id: number = 0;
    name: string = "";
    email: string = "";
    avatar: string = "";
    group: Group = new Group();
    roles: Role[] = [];
}
