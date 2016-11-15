package com.dscode.whatsgood.facade;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.StatusLine;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.util.Log;

import com.dscode.whatsgood.model.Event;
import com.dscode.whatsgood.model.IEventRepository;

public class EventFacade implements IEventRepository {

	private String serviceUrl = "http://whatsgood.azurewebsites.net/api/Events";
	private String Error = null;

	@Override
	public List<Event> GetByDate(Date startDate) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Event> GetByGenre(String genreDescription) {

		String Content = GetJsonData("?genreDescription=" + genreDescription);

		List<Event> events = MapJsonResult(Content);

		return events;
	}

	private List<Event> MapJsonResult(String content) {

		if (content == null)
			return null;

		List<Event> eventList = new ArrayList<Event>();

		JSONArray jsonResult;

		try {

			jsonResult = new JSONArray(content);

			int arrayLength = jsonResult.length();

			for (int i = 0; i < arrayLength; i++) {

				JSONObject jsonChildNode = jsonResult.getJSONObject(i);
				String description = jsonChildNode.optString("Description")
						.toString();
				String startDate = jsonChildNode.optString("StartDate")
						.toString();

				String fullPrice = jsonChildNode.optString("FullPrice")
						.toString();
				String eventId = jsonChildNode.optString("Id").toString();

				Event anEvent = new Event();
				anEvent.setName(description);
				anEvent.setPrice(Double.parseDouble(fullPrice));
				anEvent.setStartDate(GetStringDate(startDate));
				anEvent.setEventId(Integer.parseInt(eventId));

				if (jsonChildNode.has("Artist")
						&& !jsonChildNode.isNull("Artist")) {
					JSONObject artistJson = jsonChildNode
							.getJSONObject("Artist");

					if (artistJson != null) {
						String artistName = artistJson.getString("Name");
						anEvent.setArtistName(artistName);

						if (artistJson.has("Genre")
								&& !artistJson.isNull("Genre")) {

							JSONObject genreJson = artistJson
									.getJSONObject("Genre");
							if (genreJson != null) {
								String genreDescription = genreJson
										.getString("Description");
								anEvent.setGenreDescription(genreDescription);
							}
						}
					}
				}

				if (jsonChildNode.has("Promoter")
						&& !jsonChildNode.isNull("Promoter")) {
					JSONObject promoterJson = jsonChildNode
							.getJSONObject("Promoter");

					if (promoterJson != null) {
						String promoterName = promoterJson.getString("Name");
						anEvent.setPromoterName(promoterName);
						anEvent.setLocation(promoterName);
						String eventAddress = promoterJson.getString("Address");
						anEvent.setEventAddress(eventAddress);
					}
				}

				eventList.add(anEvent);
			}

		} catch (JSONException e) {

			e.printStackTrace();
		}

		return eventList;
	}

	private Date GetStringDate(String startDate) {

		SimpleDateFormat formatter = new SimpleDateFormat(
				"yyyy-MM-dd'T'HH:mm:ss.SSSZ", Locale.US);
		String dateInString = startDate;

		try {

			Date date = formatter.parse(dateInString);
			System.out.println(date);
			System.out.println(formatter.format(date));
			return date;

		} catch (ParseException e) {
			e.printStackTrace();
		}
		return new Date();
	}

	private String GetJsonData(String parameters) {

		StringBuilder builder = new StringBuilder();
		HttpClient client = new DefaultHttpClient();
		HttpGet httpGet = new HttpGet(serviceUrl + parameters);
		try {
			HttpResponse response = client.execute(httpGet);
			StatusLine statusLine = response.getStatusLine();
			int statusCode = statusLine.getStatusCode();
			if (statusCode == 200) {
				HttpEntity entity = response.getEntity();
				InputStream content = entity.getContent();
				BufferedReader reader = new BufferedReader(
						new InputStreamReader(content));
				String line;
				while ((line = reader.readLine()) != null) {
					builder.append(line);
				}
			} else {
				Log.e(EventFacade.class.toString(), "Failed to download file");
			}
		} catch (ClientProtocolException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return builder.toString();

	}

	@Override
	public List<Event> GetByArtist(String artistName) {
		// TODO Auto-generated method stub
		return null;
	}

	public String getError() {
		return Error;
	}

	public void setError(String error) {
		Error = error;
	}

}
