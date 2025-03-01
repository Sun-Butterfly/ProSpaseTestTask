class TokenService{
    static getToken() {
        return localStorage.getItem("authToken");
    }
    static setToken(token) {
        localStorage.setItem("authToken", token);
    }
    static logOut() {
        localStorage.removeItem("authToken");
    }
    static isAuthorized() {
        return this.getToken() != null;
    }
    
    static getRole() {
        let token = this.getToken();
        if (token === null) {
            return "";
        }

        let data = token.split(".")[1];
        data = window.atob(data)
        let jwt = JSON.parse(data);
        let role = jwt["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        return role;
    }
    static getId() {
        let token = this.getToken();
        if(token === null){
            return -1;
        }

        let data = token.split(".")[1];
        data = window.atob(data)
        let jwt = JSON.parse(data);
        let id  = ~~jwt["Id"]
        return id;
    }


    static removeToken() {
        localStorage.removeItem('authToken');
    }
}

export default TokenService