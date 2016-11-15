package com.dscode.whatsgood.model;

import java.util.Date;
import java.util.List;

public interface IEventRepository {	
	List<Event> GetByDate(Date startDate);
	List<Event> GetByGenre(String genreDescription);
	List<Event> GetByArtist(String artistName);
}
