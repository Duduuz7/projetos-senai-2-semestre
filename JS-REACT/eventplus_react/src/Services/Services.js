import axios from "axios";

export const eventsResource = '/Evento';
/**
 * Rota para o recurso Listar Minhas Presenças
 */
export const myEventsResource = '/PresencasEvento/ListarMinhas';
/**
 * Rota para o recurso Presenças Evento
 */
export const presencesEventResource = '/PresencasEvento';
/**
 * Rota para o recurso Presenças Evento
 */
export const commentaryEventResource = '/ComentariosEvento';

/**
 * Rota para o recurso Próximos Eventos
 */
export const nextEventResource = '/Evento/ListarProximos';
/**
 * Rota para o recurso Tipos de Eventos
 */
export const eventsTypeResource = '/TiposEvento';
/**
 * Rota para o recurso Instituição
 */
export const institutionResource = '/Instituicao';
/**
 * Rota para o recurso Login
 */
export const loginResource = '/Login';



const apiPort = "5000";
const localApi = `http://localhost:${apiPort}/api`;
const externalApi = null;

const api = axios.create({
  baseURL: localApi,
});

export default api;