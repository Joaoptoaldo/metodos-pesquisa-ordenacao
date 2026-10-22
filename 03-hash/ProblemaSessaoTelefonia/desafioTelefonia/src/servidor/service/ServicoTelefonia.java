package servidor.service;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface ServicoTelefonia extends Remote {

    String pesquisar(String numeroCelular) throws RemoteException;
}
