import { redirect } from "react-router-dom";

const GetToken = (): string | null => sessionStorage.getItem('coreToken') || localStorage.getItem('coreToken');

export const LoginLoader = async () => {
    const user = GetToken();
    if (!user ) {
      return redirect("/Login");
    }
    return null;
};